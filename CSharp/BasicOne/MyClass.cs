using BasicOne;
using System;
using System.Security.Policy;

namespace BasicOne
{


    public class MyClass : IComparable<MyClass>
    {
        public int Value { get; set; }

        public int CompareTo(MyClass other)
        {
            if (other == null)
                return 1;

            // Compare based on the 'Value' property
            return Value.CompareTo(other.Value);
        }
    }
}
