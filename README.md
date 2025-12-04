# Jogo de Roleta - Teste Técnico C#

Sistema de apostas múltiplas para roleta implementado em .NET 8.

## Como Executar
```bash
cd RouletteGame
dotnet run
```

Ou abra `RouletteGame.sln` no Visual Studio e pressione F5.

## Estrutura do Projeto
```
RouletteGame/
├── Models/
│   ├── Bet.cs              # Modelo de aposta
│   └── RouletteResult.cs   # Resultado da aposta
├── Services/
│   └── RouletteService.cs  # Lógica do jogo
└── Program.cs              # Execução principal
```

## Funcionalidades Implementadas

- ✅ Apostas múltiplas independentes
- ✅ Tipos de aposta: número cheio (36x), colunas (3x), par/ímpar (2x)
- ✅ Regra especial do zero (não é par/ímpar, não pertence a colunas)
- ✅ Validação de apostas
- ✅ Cálculo de pagamentos e lucros
- ✅ Resumo detalhado por rodada

## Tecnologias

- .NET 8
- C#
- Console Application
