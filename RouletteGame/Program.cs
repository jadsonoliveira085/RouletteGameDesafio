// ========================================
// 🎯 TESTE TÉCNICO - INSTRUÇÕES
// ========================================
//
// Você precisa implementar um sistema de jogo de roleta.
//
// PASSOS:
// 1. Criar pastas Models e Services
// 2. Criar as classes necessárias
// 3. Implementar a lógica do jogo
// 4. Substituir este código pelo código do jogo
//
// DICA: Leia o arquivo teste-backend-csharp.md para ver
// todos os detalhes do desafio!
//
// ========================================

using RouletteGame.Models;
using RouletteGame.Services;

Console.WriteLine("=======================================================================");
Console.WriteLine("               JOGO DE ROLETA - APOSTAS MULTIPLAS                      ");
Console.WriteLine("=======================================================================");

RouletteService service = new RouletteService();

// Rodada 1
Console.WriteLine("\nRODADA 1 - Apostas Variadas");

List<Bet> apostas1 = new List<Bet>();
apostas1.Add(new Bet { BetType = "even", Amount = 50 });
apostas1.Add(new Bet { BetType = "1-12", Amount = 30 });
apostas1.Add(new Bet { BetType = "number", SelectedNumber = 17, Amount = 20 });

List<RouletteResult> resultados1 = service.PlayRound(apostas1);
service.DisplaySummary(resultados1);

// Rodada 2
Console.WriteLine("\n\nRODADA 2 - Testando o Zero");

List<Bet> apostas2 = new List<Bet>();
apostas2.Add(new Bet { BetType = "odd", Amount = 100 });
apostas2.Add(new Bet { BetType = "number", SelectedNumber = 0, Amount = 10 });
apostas2.Add(new Bet { BetType = "25-36", Amount = 50 });
apostas2.Add(new Bet { BetType = "13-24", Amount = 75 });

List<RouletteResult> resultados2 = service.PlayRound(apostas2);
service.DisplaySummary(resultados2);

// Rodada 3
Console.WriteLine("\n\nRODADA 3 - Apostas Agressivas");

List<Bet> apostas3 = new List<Bet>();
apostas3.Add(new Bet { BetType = "number", SelectedNumber = 7, Amount = 25 });
apostas3.Add(new Bet { BetType = "number", SelectedNumber = 21, Amount = 25 });
apostas3.Add(new Bet { BetType = "even", Amount = 150 });
apostas3.Add(new Bet { BetType = "1-12", Amount = 100 });

List<RouletteResult> resultados3 = service.PlayRound(apostas3);
service.DisplaySummary(resultados3);

Console.WriteLine("\n=======================================================================");
Console.WriteLine("                    Fim do Jogo! Obrigado!                             ");
Console.WriteLine("=======================================================================\n");