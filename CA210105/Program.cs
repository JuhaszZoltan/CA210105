using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210105
{
    class Ember
    {
        private int _szid;
        public int Szid
        {
            get => _szid;
            set => _szid = value;
        }

        public string Nev { get; set; }

        private bool _munkanelkuli;
        private bool isMunkanelkuliSet = false;
        public virtual bool Munkanelkuli { 
            get
            {
                if (!isMunkanelkuliSet) throw new Exception("nincsbeállítva");
                return _munkanelkuli;

            }
            set
            {
                isMunkanelkuliSet = true;
                _munkanelkuli = value;
            }
        }
        public virtual void Alszik()
        {
            Console.WriteLine("ZzZzZz...");
        }
    }

    class Diak : Ember
    {
        public override bool Munkanelkuli { get; set; } = true;
        public float TanAtlag { get; set; }
    }

    class Tanar : Ember
    {
        public string Szak { get; set; }

        public override void Alszik()
        {
            Console.WriteLine("Máshogy ZzZzZz...");
        }
    }
    class Program
    {
        static void Main()
        {

            Ember ember_1 = new Ember();
            Ember ember_2 = new Diak() { TanAtlag = 2F };
            Ember ember_3 = new Tanar();


            //Console.WriteLine(ember_3.Munkanelkuli);


            var lista = new List<Ember>()
            { 
                ember_1, ember_2, ember_3
            };

            foreach (var ember in lista)
            {
                ember.Alszik();
            }

            Console.WriteLine(ember_3 is Ember);
            Console.WriteLine(ember_3 is Diak);
            Console.WriteLine(ember_3 is Tanar);

            if (ember_2 is Tanar) (ember_2 as Tanar).Szak = "Matek";

            object x = new Diak() { TanAtlag = 5F };

            Console.WriteLine((x as Ember).Munkanelkuli);

            Console.ReadKey();

        }
    }
}
