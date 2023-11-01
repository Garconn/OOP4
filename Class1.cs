using System;
// Базовий клас Живий організм 
class Organism
{
    public double Energy { get; set; }
    public int Age { get; set; }
    public double Size { get; set; }
}

// Класи Тварина, Рослина та Мікроорганізм 
class Animal : Organism
{
    public string Species { get; set; }
}

class Plant : Organism
{
    public string Type { get; set; }
}

class Microorganism : Organism
{
    public string MicroType { get; set; }
}

// Інтерфейс IReproducible для розмноження 
interface IReproducible
{
    void Reproduce();
}

// Інтерфейс IPredator для полювання 
interface IPredator
{
    void Hunt(Organism target);
}

// Клас Екосистема для моделювання взаємодії організмів 
class Ecosystem
{
    private List<Organism> organisms;

    public Ecosystem(List<Organism> organisms)
    {
        this.organisms = organisms;
    }

    public void SimulateEcosystem()
    {
        foreach (Organism organism in organisms)
        {
            if (organism is IPredator predator)
            {
                // Полювання на інших організмів 
                foreach (Organism target in organisms)
                {
                    if (target != organism && target is IReproducible)
                    {
                        predator.Hunt(target);
                    }
                }
            }
            if (organism is IReproducible reproducible)
            {
                // Розмноження організмів 
                reproducible.Reproduce();
            }
        }
    }
}

// Приклад використання: 
class Program
{
    static void Main()
    {
        Animal lion = new Animal { Energy = 100, Age = 5, Size = 2, Species = "Лев" };
        Animal gazelle = new Animal { Energy = 50, Age = 3, Size = 1, Species = "Газель" };
        Plant oakTree = new Plant { Energy = 10, Age = 10, Size = 5, Type = "Дуб" };
        Microorganism bacteria = new Microorganism { Energy = 1, Age = 1, Size = 0.01, MicroType = "Бактерія" };

        List<Organism> organisms = new List<Organism> { lion, gazelle, oakTree, bacteria };
        Ecosystem ecosystem = new Ecosystem(organisms);
        ecosystem.SimulateEcosystem();
    }
}