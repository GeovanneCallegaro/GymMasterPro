using Flunt.Notifications;
using Flunt.Validations;
using GymMasterPro.Domain.Enums;
using GymMasterPro.Shared.Validators;
using GymMasterPro.Shared.ValueObjects;

namespace GymMasterPro.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            Validate();
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool DocumentValidate()
        {
            if (Type == EDocumentType.CNPJ && Number.Length == 14)
                return true;

            if (Type == EDocumentType.CPF && DocumentValidator.IsCpfValid(Number))
                return true;

            return false;
        }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsTrue(DocumentValidate(), "Document.Number", "Documento inválido")
            );
        }
    }
}
