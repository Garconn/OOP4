using System;
using System.Collections.Generic;

// Базовий клас Комп'ютер 
class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OSType { get; set; }
}

// Класи Сервер, Робоча станція та Маршрутизатор 
class Server : Computer
{
    public string ServerType { get; set; }
}

class Workstation : Computer
{
    public string WorkstationType { get; set; }
}

class Router : Computer
{
    public string RoutingAlgorithm { get; set; }
}

// Інтерфейс IConnectable для з'єднання та передачі даних 
interface IConnectable
{
    void Connect(Computer device);
    void Disconnect(Computer device);
    void SendData(string data, Computer destination);
}

// Клас Мережа для моделювання взаємодії між комп'ютерами 
class Network
{
    private List<Computer> devices;

    public Network(List<Computer> devices)
    {
        this.devices = devices;
    }

    public void SimulateNetwork()
    {
        foreach (Computer device in devices)
        {
            if (device is IConnectable connectableDevice)
            {
                // З'єднання та передача даних між пристроями 
                foreach (Computer otherDevice in devices)
                {
                    if (otherDevice != device)
                    {
                        connectableDevice.Connect(otherDevice);
                        connectableDevice.SendData("Привіт!", otherDevice);
                        connectableDevice.Disconnect(otherDevice);
                    }
                }
            }
        }
    }
}