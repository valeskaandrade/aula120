using Teste.Entities.Enums;
using System.Collections.Generic; // para usar o List

namespace Teste.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        //composição de objetos (relação entre duas classes diferentes)
        public Department  Department { get; set; } //relaçao 1 pra 1
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // relação 1 pra n e a lista foi instanciada para que ela não seja nula
        public Worker()
        { }

        // não incluiu a relação 1 para n, não é usual passar uma lista no construtor
        // ela vai começar vazia, e vamos adicionado os objetos na medida da necessidade
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }
        public void AddContract (HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        public double Income(int year, int month)  // Income => Significa quanto que o worker ganhou em um dado ano e um dado mês
        {
            double sum = BaseSalary;

            foreach(HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;

        }        
    }

}
