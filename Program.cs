using System;
using Teste.Entities;
using Teste.Entities.Enums;
using System.Globalization;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            /*aula 121 Ler os dados de um trabalhador com N contratos(N fornecido pelo usuário).Depois, solicitar
            do usuário um mês e mostrar qual foi o salário do funcionário nesse mês */
            Console.Write("Informe o nome do departamento: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Informe os dados do trabalhador: ");

            Console.Write("Nome: ");
            string workerName = Console.ReadLine();

            Console.Write("Nível(Junior/MidLevel/Senior): ");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Salário Base: ");
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(workerName, workerLevel, baseSalary, dept);
            Console.Write("Quantos contratos para esse trabalhador: ");
            int n = int.Parse (Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com os dados do contrato #{i}");
                
                Console.Write("Data: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                
                Console.Write("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duração(horas): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract hourContract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(hourContract);

            }
            Console.WriteLine("Entre com o mês e ano para calcular o ganho no formato MM/YYYY");
            string mesAno = Console.ReadLine();

            int mes = int.Parse(mesAno.Substring(0, 2));
            int ano = int.Parse(mesAno.Substring(3));
            double income = worker.Income(ano, mes);

            Console.WriteLine("Trabalhador: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine($"Ganho em {mesAno} : {income.ToString("F2")}");
        }
    }
}
