using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoDocker.Shared
{
    public interface IInitializationStage
    {
        int Order { get; }
        Task ExecuteAsync();
    }
}
