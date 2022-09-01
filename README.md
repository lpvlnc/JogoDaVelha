# JogoDaVelha
## Como jogar
Ao iniciar o jogo será exibido aos jogadores:
- O  tabuleiro.
- O jogador da vez.
- As posições disponíveis para marcar.
- O input de qual posição o jogador da vez deseja marcar.
```
[1]|[2]|[3]
---|---|---
[4]|[5]|[6]
---|---|---
[7]|[8]|[9]

Jogador 1, é a sua vez.

Posiçoes disponíveis:
[1] - [2] - [3] - [4] - [5] - [6] - [7] - [8] - [9]

Digite a posiçao escolhida:
```
Neste exemplo, vamos supor que o jogador 1 (X) escolheu a posição 5.
Quando o jogador 1 marcar a posição 5, que é uma das posições disponíveis listadas acima, o tabuleiro será atualizado para o próximo jogador marcar sua posição.
```
[1]|[2]|[3]
---|---|---
[4]| X |[6]
---|---|---
[7]|[8]|[9]

Jogador 2, é a sua vez.

Posiçoes disponíveis:
[1] - [2] - [3] - [4] - [6] - [7] - [8] - [9]

Digite a posiçao escolhida:
```
Como a posição 5 já foi marcada pelo jogador 1 (X), o jogador 2 (O) não poderá marcar a mesma, ela é excluída da lista das posições disponíveis.
Este fluxo irá se repetir até que o jogo acabe.

Caso algum dos jogadores digite algo inesperado no lugar da posição, como por exemplo uma letra ou uma posição que já foi marcada, será exibida uma mensagem de erro e uma nova solicitação ao usuário para que ele digite uma das posições válidas. No exemplo abaixo o jogador 1 (X) digitou a letra 'A'no lugar das posições:
```
[1]|[2]|[3]
---|---|---
 O | X |[6]
---|---|---
[7]|[8]|[9]

Jogador 1, é a sua vez.

Posiçoes disponíveis:
[1] - [2] - [3] - [6] - [7] - [8] - [9]

Digite a posiçao escolhida:
A

Posiçao inválida!
Jogador 1, escolha uma das seguintes posiçoes disponíveis:
[1] - [2] - [3] - [6] - [7] - [8] - [9]
Digite a posiçao escolhida:
```
## Quando acaba o jogo?
O jogo acaba quando:
- Um dos jogadores conseguir fazer uma linha na horizontal, vertical ou diagonal com 3 marcações.
- Todas as posições forem marcadas, mesmo que nenhum dos jogadores tenha conseguido formar uma linha com 3 marcações.
Caso um dos jogadores consiga vencer, será exibido na tela o jogador que venceu junto com uma pergunta, para saber se os jogadores desejam jogar novamente.
```
 O |[2]| X
---|---|---
 O | X |[6]
---|---|---
 X |[8]|[9]

O vencedor foi o jogador  X .

Desejam jogar novamente? [s/n]
```
Caso a resposta seja 'n' (Não), o jogo é encerrado.
```
 O |[2]| X
---|---|---
 O | X |[6]
---|---|---
 X |[8]|[9]

Fim do jogo.
```
caso a resposta seja 's' (Sim), o jogo é reiniciado para uma nova partida.
```
[1]|[2]|[3]
---|---|---
[4]|[5]|[6]
---|---|---
[7]|[8]|[9]

Jogador 1, é a sua vez.

Posiçoes disponíveis:
[1] - [2] - [3] - [4] - [5] - [6] - [7] - [8] - [9]

Digite a posiçao escolhida:
```
