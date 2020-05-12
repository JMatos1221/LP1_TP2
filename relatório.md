 # Felli

 ---
 André Figueira 21901435
 
 João Matos 21901219

 Miguel Feliciano 21904115
 
 ---

## Commits e Trabalho  Realizado

1. **First Commit** - João Matos
    - Criação da solução.
2. **Classes and Board Design** - João Matos
    - Design e criação do tabuleiro de jogo.
3. **Instructions and Game Start Added** - André Figueira
    - Criação das introduções do jogo e começo do jogo.
4. **Finished Game** - Miguel Feliciano
    - Primeira versão do jogo concluída.
5. **Board Redesign and Game Polish** - João Matos .
    - Redesign do tabuleiro de jogo e *polish*
6. **Comments and small Bug Fix added** - André Figueira 
    - Comentários XML adicionados e resolução de alguns bugs.
7. **Report Added** - Miguel Feliciano
    - Relatório adicionado.

---

## **Arquitetura da Solução**  

Para a solução do nosso projeto, começámos por desenhar como seria feito o jogo em termos de input e output, ou seja, desenhámos os passos que teríamos de realizar até chegar ao game loop. Começámos então por fazer uma enumeração para distinguir os players, onde mais tarde adicionámos `None`, para ser utilizado nas coordenadas do tabuleiro sem peça. De seguida, fizemos a parte para receber input para definir a cor que o Jogador A escolhia, definindo assim também a cor para o Jogador B (se um jogador é branco o outro é preto). Após isto feito, perguntamos qual dos jogador começava a jogar, para definirmos as condições necessárias para o ínicio do jogo, seguindo-se assim o Game Loop.

No Game Loop é sempre imprimido qual o jogador que tem o turno e o tabuleiro do jogo, depois é esperado um comando do jogador, sendo esse comando a jogada, `help` ou `quit`, outros comandos não são válidos e imprimem uma mensagem de erro, e "repetem o turno". Este é o loop principal que é sempre executado, e onde a sua última instrução é a verificação do jogo, definindo a variável `run` de modo a que o loop tenha fim quando existe um jogador sem peças, e logo de seguida imprimindo a mensagem do jogador vencedor. O programa termina quando o jogo acaba.

---
## **Diagrama UML**

![Diagrama UML](FelliUML.png)
