﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public enum ContractType
    {
    Valid,
    ValidInFuture,
    Invalid,
    ErrorInInput
    };
}
