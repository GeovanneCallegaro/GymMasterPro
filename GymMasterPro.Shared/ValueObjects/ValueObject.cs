using Flunt.Notifications;

namespace GymMasterPro.Shared.ValueObjects
{
    public class ValueObject : Notifiable<Notification>
    {
        protected virtual void Validate() { }
    }
}
