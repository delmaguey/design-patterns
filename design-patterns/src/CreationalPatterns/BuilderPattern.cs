namespace Patterns.Creational
{
    
    // The Builder interface specifies methods for creating the different parts
    // of the Product objects.
    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    // The Concrete Builder class follow the Builder interface and provide
    // specific implementations of the building steps. 
    public class ConcreteBuilder: IBuilder
    {
        private Product _product = new Product();

        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildPartA()
        {
            this._product.Add("PartA1");
        }

        public void BuildPartB()
        {
            this._product.Add("PartB1");
        }

        public void BuildPartC()
        {
            this._product.Add("PartC1");
        }


        // Concrete Builders are supposed to provide their own methods for retrieving results.
        // That's because various types of builders may create entirely different products that don't follow the same interface.  
        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }



    public class Product
    {
        private List<object> _parts = new List<object>();
    

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for(int i=0;i<this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length -2); // removing last comma and space

            return "Product parts: " + str + "\n";
        }
    }


    public class Director
        {
            private IBuilder _builder;
            
            public IBuilder Builder
            {
                set { _builder = value; } 
            }
            
            // The Director can construct several product variations using the same building steps.
            public void BuildMinimalViableProduct()
            {
                this._builder.BuildPartA();
            }
            
            public void BuildFullFeaturedProduct()
            {
                this._builder.BuildPartA();
                this._builder.BuildPartB();
                this._builder.BuildPartC();
            }
        }



}