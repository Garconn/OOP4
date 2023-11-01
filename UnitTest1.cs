using System;
using System.Collections.Generic;

// ������� ���� ����'���� 
class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OSType { get; set; }
}

// ����� ������, ������ ������� �� ������������� 
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

// ��������� IConnectable ��� �'������� �� �������� ����� 
interface IConnectable
{
    void Connect(Computer device);
    void Disconnect(Computer device);
    void SendData(string data, Computer destination);
}

// ���� ������ ��� ����������� �����䳿 �� ����'������� 
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
                // �'������� �� �������� ����� �� ���������� 
                foreach (Computer otherDevice in devices)
                {
                    if (otherDevice != device)
                    {
                        connectableDevice.Connect(otherDevice);
                        connectableDevice.SendData("�����!", otherDevice);
                        connectableDevice.Disconnect(otherDevice);
                    }
                }
            }
        }
    }
}