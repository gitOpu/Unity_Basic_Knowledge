using BasicOne;
using System;
using System.Security.Policy;

namespace BasicOne
{
      class HelpAttribute : Attribute
    {
        public readonly string Url;
        public HelpAttribute(string url)
        {
            this.Url = url;
        }

        public string Topic     {
              get {
                 return topic;
              }
            set {
                 topic = value;
              }
            }
 
   private string topic;
    }
}