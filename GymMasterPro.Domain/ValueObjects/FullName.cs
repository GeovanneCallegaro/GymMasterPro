using Flunt.Notifications;
using Flunt.Validations;
using GymMasterPro.Shared.ValueObjects;

namespace GymMasterPro.Domain.ValueObjects
{
    public class FullName : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            Validate();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }


        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNullOrEmpty(FirstName, "FullName.FirstName", "FullName.FirstName não pode ser null")
                .IsGreaterOrEqualsThan(FirstName, 3, "FullName.FirstName", "FullName.FirstName tem que ser maior ou igual a três caracteres")
                .IsNullOrEmpty(LastName, "FullName.LastName", "FullName.LastName não pode ser null")
                .IsGreaterOrEqualsThan(LastName, 3, "FullName.LastName", "FullName.LastName tem que ser maior ou igual a três caracteres"));
        }
    }
}
