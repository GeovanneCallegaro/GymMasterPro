using GymMasterPro.Domain.ValueObjects;
using Flunt.Notifications;

namespace GymMasterPro.Domain.Entities
{
    public class Gym : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public GymOwner Owner { get; private set; }

        public Gym(int id, Name name, Address address, GymOwner owner)
        {
            Id = id;
            Name = name;
            Address = address;
            Owner = owner;

            AddNotifications(Name, Address);
        }
    }
}
