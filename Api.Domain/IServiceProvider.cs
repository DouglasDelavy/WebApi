using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain
{
    public interface IServiceProvider
    {
        T GetService<T>();
    }
}
