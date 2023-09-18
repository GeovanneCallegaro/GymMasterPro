using Flunt.Notifications;
using Flunt.Validations;
using GymMasterPro.Shared.ValueObjects;

namespace GymMasterPro.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string SimpleName { get; private set; }

        public Name(string simpleName) 
        { 
            SimpleName = simpleName;
            Validate();
        }

        public override string ToString()
        {
            return $"{SimpleName}";
        }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNullOrEmpty(SimpleName, "Name.SimpleName", "Name.SimpleName não pode ser null")
                .IsGreaterOrEqualsThan(SimpleName, 3, "Name.SimpleName", "Name.SimpleName tem que ser maior ou igual a três caracteres"));
        }
    }
}
