using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUnitWork : IDisposable
    {
        IPersonaRepository PersonaRepository { get; }
        Task <int> CommitAsync();
    }
}
