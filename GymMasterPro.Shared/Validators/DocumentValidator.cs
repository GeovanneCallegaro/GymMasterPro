namespace GymMasterPro.Shared.Validators
{
    public static class DocumentValidator
    {
        public static bool IsCpfValid(string cpf)
        {
            if (!cpf.All(char.IsDigit) || cpf.Length != 11)
            {
                return false;
            }

            var digits = cpf.Select(c => c - '0').ToArray();

            var firstCheckDigit = CalculateCheckDigit(digits, 10);
            var secondCheckDigit = CalculateCheckDigit(digits, 11);

            return digits[9] == firstCheckDigit && digits[10] == secondCheckDigit;
        }

        public static bool IsCnpjValid(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14 || !IsAllDigits(cnpj))
            {
                return false;
            }

            var digits = Array.ConvertAll(cnpj.ToCharArray(), c => (int)char.GetNumericValue(c));

            int[] firstMultipliers = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] secondMultipliers = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var firstSum = 0;
            for (int i = 0; i < 12; i++)
            {
                firstSum += digits[i] * firstMultipliers[i];
            }
            var firstRemainder = firstSum % 11;
            var firstDigit = (firstRemainder < 2) ? 0 : 11 - firstRemainder;

            var secondSum = 0;
            for (int i = 0; i < 13; i++)
            {
                secondSum += digits[i] * secondMultipliers[i];
            }
            var secondRemainder = secondSum % 11;
            var secondDigit = (secondRemainder < 2) ? 0 : 11 - secondRemainder;

            return digits[12] == firstDigit && digits[13] == secondDigit;
        }

        private static int CalculateCheckDigit(int[] digits, int factor)
        {
            var sum = 0;
            for (int i = 0; i < factor - 1; i++)
            {
                sum += digits[i] * (factor - i);
            }

            var remainder = sum % 11;
            return (remainder < 2) ? 0 : 11 - remainder;
        }

        private static bool IsAllDigits(string input)
        {
            return input.All(char.IsDigit);
        }
    }
}

