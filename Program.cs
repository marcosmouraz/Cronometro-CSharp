using System;
using System.Threading;

namespace Cronometro
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            // Limpa o console para deixar a interface mais limpa a cada vez que o menu é chamado
            Console.Clear();

            // Exibe opções para o usuário sobre como definir o tempo do cronômetro
            Console.WriteLine("S = Segundos => 10s = 10 segundos");
            Console.WriteLine("M = Minutos => 1m = 1 minuto");
            Console.WriteLine("Quanto tempo deseja contar?");
            Console.WriteLine("---------------------------");
            Console.WriteLine("0 = Sair");

            // Captura a entrada do usuário e converte tudo para minúsculo para evitar erros de digitação
            string data = Console.ReadLine().ToLower();

            // Obtém o último caractere da string digitada pelo usuário para determinar se é 's' (segundos) ou 'm' (minutos)
            char type = char.Parse(data.Substring(data.Length - 1, 1));

            // Obtém a parte numérica da entrada do usuário (remove o último caractere que indica o tipo de tempo)
            int time = int.Parse(data.Substring(0, data.Length - 1));

            // Define um multiplicador para converter minutos em segundos (padrão é 1, pois segundos não precisam de conversão)
            int multiplicador = 1;

            // Se o usuário escolheu minutos, define o multiplicador como 60 para converter em segundos
            if (type == 'm')
                multiplicador = 60;

            // Se o usuário digitou 0, encerra o programa
            if (time == 0)
                System.Environment.Exit(0);

            // Chama a função PreStart passando o tempo total em segundos (convertido se necessário)
            PreStart(time * multiplicador);
        }

        static void PreStart(int time)
        {
            // Limpa o console para exibir a contagem regressiva de forma organizada
            Console.Clear();

            // Mensagem de preparação antes de iniciar a contagem regressiva
            Console.WriteLine("Preparar...");
            Thread.Sleep(1000); // Aguarda 1 segundo

            Console.WriteLine("Apontar...");
            Thread.Sleep(1000); // Aguarda mais 1 segundo

            Console.WriteLine("FOGO!");
            Thread.Sleep(2000); // Aguarda 2 segundos antes de iniciar o cronômetro

            // Chama a função Start() passando o tempo definido pelo usuário
            Start(time);
        }

        static void Start(int time)
        {
            // Variável para acompanhar o tempo decorrido
            int currentTime = 0;

            // Loop que continua até o tempo escolhido pelo usuário ser atingido
            while (currentTime != time)
            {
                Console.Clear(); // Limpa o console para atualizar a contagem corretamente
                currentTime++; // Incrementa o tempo decorrido em 1 segundo
                Console.WriteLine(currentTime); // Exibe o tempo atual no console
                Thread.Sleep(1000); // Aguarda 1 segundo antes da próxima atualização
            }

            // Quando o tempo termina, exibe a mensagem de conclusão
            Console.Clear();
            Console.WriteLine("Cronômetro Finalizado!");
            Thread.Sleep(2500); // Aguarda 2 segundos para que o usuário veja a mensagem

            // Retorna ao menu principal para uma nova contagem ou sair do programa
            Menu();
        }

    }
}