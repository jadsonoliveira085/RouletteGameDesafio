using System;

namespace RouletteGame.Models
{
    public class RouletteResult
    {
        public Bet Bet { get; set; }
        public int DrawnNumber { get; set; }
        public bool Won { get; set; }
        public decimal Payout { get; set; }
        public decimal Profit { get; set; }

        public RouletteResult()
        {
            Bet = new Bet();
        }

        public void DisplayResult()
        {
            string status = Won ? "GANHOU" : "PERDEU";

            Console.Write("  " + Bet.GetDescription().PadRight(20) + " | ");
            Console.Write("Aposta: R$ " + Bet.Amount.ToString("F2").PadRight(8) + " | ");
            Console.Write(status.PadRight(7) + " | ");

            if (Won)
                Console.WriteLine("Retorno: R$ " + Payout.ToString("F2"));
            else
                Console.WriteLine("Retorno: R$ 0,00");
        }
    }
}