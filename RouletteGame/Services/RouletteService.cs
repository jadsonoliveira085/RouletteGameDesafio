using RouletteGame.Models;
using System;
using System.Collections.Generic;

namespace RouletteGame.Services
{
    public class RouletteService
    {
        private Random random;

        public RouletteService()
        {
            random = new Random();
        }

        public int SpinRoulette()
        {
            return random.Next(0, 37);
        }

        public List<RouletteResult> PlayRound(List<Bet> bets)
        {
            int numeroSorteado = SpinRoulette();
            List<RouletteResult> resultados = new List<RouletteResult>();

            Console.WriteLine("\nNumero sorteado: " + numeroSorteado);
            Console.WriteLine("   " + GetNumberInfo(numeroSorteado) + "\n");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (var aposta in bets)
            {
                if (!aposta.IsValid())
                {
                    Console.WriteLine("Aposta invalida: " + aposta.GetDescription());
                    continue;
                }

                RouletteResult resultado = CheckBet(aposta, numeroSorteado);
                resultados.Add(resultado);
                resultado.DisplayResult();
            }

            return resultados;
        }

        private RouletteResult CheckBet(Bet bet, int numeroSorteado)
        {
            RouletteResult resultado = new RouletteResult();
            resultado.Bet = bet;
            resultado.DrawnNumber = numeroSorteado;
            resultado.Won = false;
            resultado.Payout = 0;

            string tipoBet = bet.BetType.ToLower();

            if (tipoBet == "number")
            {
                if (bet.SelectedNumber == numeroSorteado)
                {
                    resultado.Won = true;
                    resultado.Payout = bet.Amount * 36;
                }
            }
            else if (tipoBet == "even")
            {
                if (numeroSorteado != 0 && numeroSorteado % 2 == 0)
                {
                    resultado.Won = true;
                    resultado.Payout = bet.Amount * 2;
                }
            }
            else if (tipoBet == "odd")
            {
                if (numeroSorteado != 0 && numeroSorteado % 2 != 0)
                {
                    resultado.Won = true;
                    resultado.Payout = bet.Amount * 2;
                }
            }
            else if (tipoBet == "1-12")
            {
                if (numeroSorteado >= 1 && numeroSorteado <= 12)
                {
                    resultado.Won = true;
                    resultado.Payout = bet.Amount * 3;
                }
            }
            else if (tipoBet == "13-24")
            {
                if (numeroSorteado >= 13 && numeroSorteado <= 24)
                {
                    resultado.Won = true;
                    resultado.Payout = bet.Amount * 3;
                }
            }
            else if (tipoBet == "25-36")
            {
                if (numeroSorteado >= 25 && numeroSorteado <= 36)
                {
                    resultado.Won = true;
                    resultado.Payout = bet.Amount * 3;
                }
            }

            resultado.Profit = resultado.Payout - bet.Amount;
            return resultado;
        }

        private string GetNumberInfo(int num)
        {
            if (num == 0)
                return "(Zero - nao e par nem impar, nao pertence a nenhuma coluna)";

            string parOuImpar = num % 2 == 0 ? "Par" : "Impar";

            string coluna = "";
            if (num >= 1 && num <= 12)
                coluna = "Coluna 1-12";
            else if (num >= 13 && num <= 24)
                coluna = "Coluna 13-24";
            else
                coluna = "Coluna 25-36";

            return "(" + parOuImpar + ", " + coluna + ")";
        }

        public void DisplaySummary(List<RouletteResult> results)
        {
            Console.WriteLine("---------------------------------------------------------------------");

            decimal totalApostado = 0;
            decimal totalGanho = 0;

            foreach (var r in results)
            {
                totalApostado += r.Bet.Amount;
                totalGanho += r.Payout;
            }

            decimal lucroFinal = totalGanho - totalApostado;

            Console.WriteLine("\nRESUMO DA RODADA:");
            Console.WriteLine("   Total apostado: R$ " + totalApostado.ToString("F2"));
            Console.WriteLine("   Total ganho:    R$ " + totalGanho.ToString("F2"));

            if (lucroFinal > 0)
                Console.WriteLine("   Lucro final:    R$ " + lucroFinal.ToString("F2"));
            else if (lucroFinal < 0)
                Console.WriteLine("   Prejuizo final: R$ " + lucroFinal.ToString("F2"));
            else
                Console.WriteLine("   Resultado:      R$ 0,00 (Empate)");
        }
    }
}