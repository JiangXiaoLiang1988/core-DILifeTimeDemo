using DILifeTimeDemo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DILifeTimeDemo.Domain
{
    public class GuidService : IGuidService
    {
        private readonly Guid _guid;

        public GuidService()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
