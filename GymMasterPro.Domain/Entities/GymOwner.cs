using Flunt.Notifications;
using GymMasterPro.Domain.ValueObjects;

namespace GymMasterPro.Domain.Entities
{
    public class GymOwner : Notifiable<Notification>
    {
        private IList<Gym> _gyms;

        public Guid Id { get; private set; }
        public FullName Name { get; private set; }
        public Address Address { get; private set; }
        public Document Document { get; private set; }
        public IReadOnlyCollection<Gym> Gyms { get { return _gyms.ToArray();  } }
        public GymOwner(FullName name, Address address, Document document)
        {
            Id = new Guid();
            Name = name;
            Address = address;
            Document = document;
            _gyms = new List<Gym>();
        }
    }
}
