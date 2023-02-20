using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyModbus;

namespace devicemonitoring
{
    class zReadDevice
    {
        public int startRegister;
        public int jumlahRegister;
        public string ipaddress;

        public int[] data;

        public int X;
        public zReadDevice()
        {
            //Console.WriteLine(ipaddress);
            //this.DeviceData = ipaddress;
        }

        
        
    }
}

/*

try
{
    ModbusClient modbusClient = new ModbusClient(ipaddress, 502);
    modbusClient.Connect();
    return data = modbusClient.ReadHoldingRegisters(startRegister, jumlahRegister);
    modbusClient.Disconnect();
}
catch (Exception error)
{
                    
}; 




*/