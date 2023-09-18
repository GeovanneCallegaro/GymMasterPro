using Flunt.Notifications;
using Flunt.Validations;
using GymMasterPro.Shared.ValueObjects;

namespace GymMasterPro.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; } 
        public string Country { get; private set;}
        public string ZipCode { get; private set;}

        public Address(string street, string number, string neighborhood, string city, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            Country = country;
            ZipCode = zipCode;

            Validate();
        }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(Street, 3, "Address.Street", "A rua deve ser igual ou ter mais de 3 caracteres")
                .IsNotNullOrWhiteSpace(Number, "Address.Number", "O número não pode ser vazio")
                .IsGreaterOrEqualsThan(Neighborhood, 3, "Address.Neighborhood", "O bairro deve ser igual ou ter mais de 3 caracteres")
                .IsGreaterOrEqualsThan(City, 3, "Address.City", "A cidade deve ser igual ou ter mais de 3 caracteres")
                .IsGreaterOrEqualsThan(Country, 3, "Address.Country", "O país deve ser igual ou ter mais de 3 caracteres")
                .AreEquals(ZipCode, 8, "Address.ZipCode", "O código postal deve ter exatamente 8 caracteres"));
        }
    }
}
