using System;

namespace Media_alunos
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcoesMenu = ObterOpcoesTela();

            while (opcoesMenu != "X")
            {
                switch (opcoesMenu)
                {
                    case "1":
                        Console.Write("Informe o nome: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.Write("Informe a nota: ");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
                            aluno.Nota = nota;
                        }else{
                            throw new ArgumentException("O valor deve ser numerico");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach (Aluno item in alunos)
                        {
                            if(!string.IsNullOrEmpty(item.Nome))
                            {
                                Console.WriteLine($"Aluno: {item.Nome} | Nota: {item.Nota}");
                            }          
                        }

                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        int tAlunos = 0;
                        ConceitoEnum conceitoGeral;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome)){
                               notaTotal += alunos[i].Nota; 
                               tAlunos++;
                            }
                        }

                        decimal media = notaTotal / tAlunos;

                        if(media < 2){
                            conceitoGeral = ConceitoEnum.E;
                        }else if( media < 4){
                            conceitoGeral = ConceitoEnum.D;
                        }else if(media < 6){
                            conceitoGeral = ConceitoEnum.C;
                        }else if(media < 8){
                            conceitoGeral = ConceitoEnum.B;
                        }else{
                            conceitoGeral = ConceitoEnum.A;
                        }

                        Console.WriteLine($"Media das notas de : {tAlunos} alunos | Media Geral: {media} | Conceito geral: {conceitoGeral}");
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcoesMenu = ObterOpcoesTela();
            }
        }

        private static string ObterOpcoesTela()
        {
            Console.Clear();
            Console.WriteLine("Informe a opção: ");
            Console.WriteLine("1- Inserir aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular media geral");
            Console.WriteLine("X- Sair");

            string opcoesMenu = Console.ReadLine().ToUpper();
            Console.Clear();

            return opcoesMenu;
        }
    }
}
