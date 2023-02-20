using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devicemonitoring
{
    class TestLearnClass
    {
        private int id; //field

        public int StudentId       // property
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName { get; set; }   //auto implement property
        public string LastName { get; set; }    //auto implement property

        public int sum(int num1, int num2)  //Method
        {
            var total = num1 + num2;
            return total;
        }

        public void Greet()  // Method doesn't return anything and doesn't have any parameters
        {
            Console.WriteLine("Hello World");
        }

        public string GetFullName()     //Method - The following defines the GetFullName() method in the Student class.
        {
            return FirstName + " " + LastName;
        }


        public TestLearnClass()    //Constructor - automatic call this constructor when object created
        {

        }
    }
}
