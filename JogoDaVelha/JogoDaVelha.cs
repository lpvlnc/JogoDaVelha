namespace JogoDaVelha
{
    public class JogoDaVelha
    {
        private string[] _posicoes = new[] { "[1]", "[2]", "[3]", "[4]", "[5]", "[6]", "[7]", "[8]", "[9]" };
        private bool _acabou = false;
        private int _jogadas = 0;

        public JogoDaVelha()
        {
            IniciarJogo();
        }

        private void IniciarJogo()
        {
            while (!_acabou)
                LerJogada();
        }

        private void LerJogada()
        {
            bool posicaoValida = false;
            int posicao = -1;
            ExibirTabela();
            string mensagem = $"\nJogador {JogadorAtual()}, é a sua vez.\n\n" +
                               "Posições disponíveis:\n" +
                              $"{PosicoesDisponiveis()}\n\n" +
                              "Digite a posição escolhida: ";
            Console.WriteLine(mensagem);
            while (!posicaoValida)
            {
                posicao = (int)Char.GetNumericValue(Console.ReadKey().KeyChar) - 1;
                posicaoValida = ValidarPosicao(posicao);
            }
            MarcarPosicao(posicao);
        }

        private void ExibirTabela()
        {
            Console.Clear();
            string tabela = $"{_posicoes[0]}|{_posicoes[1]}|{_posicoes[2]}\n" +
                             "---|---|---\n" +
                            $"{_posicoes[3]}|{_posicoes[4]}|{_posicoes[5]}\n" +
                             "---|---|---\n" +
                            $"{_posicoes[6]}|{_posicoes[7]}|{_posicoes[8]}";
            Console.WriteLine(tabela);
        }

        private string JogadorAtual()
        {
            return _jogadas % 2 == 0 ? "1" : "2";
        }

        private string PosicoesDisponiveis()
        {
            string posicoesDisponiveis = "";
            foreach (string posicao in _posicoes)
            {
                if (!posicao.Equals(" X ") && !posicao.Equals(" O "))
                    posicoesDisponiveis += $"{posicao} - ";
            }

            return string.IsNullOrEmpty(posicoesDisponiveis) ? posicoesDisponiveis : posicoesDisponiveis[0..^3];
        }

        private bool ValidarPosicao(int posicao)
        {
            if (posicao == -1 || posicao < 0 || posicao > 8 || _posicoes[posicao].Equals(" X ") || _posicoes[posicao].Equals(" O "))
            {
                string mensagem = "\n\nPosição inválida!\n" +
                                 $"Jogador {JogadorAtual()}, escolha uma das seguintes posições disponíveis:\n" +
                                 $"{PosicoesDisponiveis()}\n" +
                                  "Digite a posição escolhida: "; ;
                Console.WriteLine(mensagem);
                return false;
            }
            return true;
        }

        private void MarcarPosicao(int posicao)
        {
            string marcacao = JogadorAtual() == "1" ? "X" : "O";
            _posicoes[posicao] = $" {marcacao} ";
            _jogadas++;
            ValidarFimDeJogo();
        }
        
        private void ValidarFimDeJogo()
        {
            VerificarSeHouveVencedor();
            VerificarSeAindaHaPosicoesDisponiveis();
            
            if (_acabou)
                VerificarSeQueremJogarNovamente();
        }

        private void VerificarSeHouveVencedor()
        {
            string vencedor = "";

            // Verifica as posições horinzontais da tabela
            if (_posicoes[0].Equals(_posicoes[1]) && _posicoes[0].Equals(_posicoes[2]))
                vencedor = _posicoes[0];
            if (_posicoes[3].Equals(_posicoes[4]) && _posicoes[3].Equals(_posicoes[5]))
                vencedor = _posicoes[3];
            if (_posicoes[6].Equals(_posicoes[7]) && _posicoes[6].Equals(_posicoes[8]))
                vencedor = _posicoes[6];

            // Verifica as posições verticais da tabela
            if (_posicoes[0].Equals(_posicoes[3]) && _posicoes[0].Equals(_posicoes[6]))
                vencedor = _posicoes[0];
            if (_posicoes[1].Equals(_posicoes[4]) && _posicoes[1].Equals(_posicoes[7]))
                vencedor = _posicoes[1];
            if (_posicoes[2].Equals(_posicoes[5]) && _posicoes[2].Equals(_posicoes[8]))
                vencedor = _posicoes[2];

            // Verifica as posições diagonais da tabela
            if (_posicoes[0].Equals(_posicoes[4]) && _posicoes[0].Equals(_posicoes[8]))
                vencedor = _posicoes[0];
            if (_posicoes[2].Equals(_posicoes[4]) && _posicoes[2].Equals(_posicoes[6]))
                vencedor = _posicoes[2];

            if (!string.IsNullOrEmpty(vencedor))
            {
                ExibirTabela();
                Console.WriteLine($"\nO vencedor foi o jogador {vencedor}.");
                _acabou = true;
            }
        }

        private void VerificarSeAindaHaPosicoesDisponiveis()
        {
            if (string.IsNullOrEmpty(PosicoesDisponiveis()))
            {
                ExibirTabela();
                Console.WriteLine("\nNão houve vencedores.");
                _acabou = true;
            }
        }

        private void VerificarSeQueremJogarNovamente()
        {
            char resposta = ' ';
            while (!resposta.Equals('s') && !resposta.Equals('n'))
            {
                Console.WriteLine("\nDesejam jogar novamente? [s/n]");
                resposta = char.ToLower(Console.ReadKey().KeyChar);
            }

            if (resposta.Equals('s'))
            {
                _jogadas = 0;
                _posicoes = new[] { "[1]", "[2]", "[3]", "[4]", "[5]", "[6]", "[7]", "[8]", "[9]" };
                _acabou = false;
            }
            else
            {
                _acabou = true;
                ExibirTabela();
                Console.WriteLine("\nFim do jogo.");
            }
        }
    }
}
