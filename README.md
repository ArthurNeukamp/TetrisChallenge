# TetrisChallenge
Desafio 1, com intuito de fortalecer a lógica e estrutura/arquitetura do programa.
  * Design ainda a ser feito! (Imagens no lugar das cores no grid, botões e estrutura visual);
  * Lógicas feitas com base nas regras do Tetris
  * Banco de dados:
      * Tela inicial colocando o nome do jogador, sem tratamento de Username;
      * Em ranking pode-se ver o TOP 10 jogadores vinculados ao banco de dados existente;
      * Ao fim do jogo (GameOver), é registrado o jogador e sua pontuação
          * OBS.: Se o jogador existe, a pontuação atual só é registrada se ela for superior àquela que está registrada (analisar procedure de inserção no SSMS).
      * O banco de dados está disponível na pasta (.BAK), analisar string de conexão na classe Database e implementar conforme o uso localhost.
      * Verificar se as procedures estão funcionando corretamente.
