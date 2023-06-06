using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ItsUmbria2023.Models
{
    public class IdentityCard
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        private string Something2 { get; set; }
        public string Something
        {
            get
            {
                return _something + "a";
            }
            set
            {
                _something = value;
            }
        }
        private string _something;
        public void SetSomething(string value)
        {
            this._something = value;
        }
        public string GetSomething()
        {
            return this._something + "a";
        }
    }
}
