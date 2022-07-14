using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seriess
{
    /*Classe a ser usada como base*/
    public abstract class EntidadeBase
    {
        /*Id é protegido para setar, mas nao para pegar*/
        public int Id { get; protected set; }
    }
}