namespace RouletteGame.Models
{
    public class Bet
    {
        public string BetType { get; set; }
        public int? SelectedNumber { get; set; }
        public decimal Amount { get; set; }

        public Bet()
        {
            BetType = "";
        }

        public bool IsValid()
        {
            if (Amount <= 0)
                return false;

            string tipo = BetType.ToLower();

            if (tipo == "number")
            {
                if (!SelectedNumber.HasValue)
                    return false;

                if (SelectedNumber.Value < 0 || SelectedNumber.Value > 36)
                    return false;

                return true;
            }

            if (tipo == "even" || tipo == "odd")
                return true;

            if (tipo == "1-12" || tipo == "13-24" || tipo == "25-36")
                return true;

            return false;
        }

        public string GetDescription()
        {
            string tipo = BetType.ToLower();

            if (tipo == "number")
                return "Numero " + SelectedNumber;

            if (tipo == "even")
                return "Par";

            if (tipo == "odd")
                return "Impar";

            if (tipo == "1-12")
                return "Coluna 1-12";

            if (tipo == "13-24")
                return "Coluna 13-24";

            if (tipo == "25-36")
                return "Coluna 25-36";

            return "Tipo desconhecido";
        }
    }
}