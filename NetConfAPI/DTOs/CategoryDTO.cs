﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetConfAPI.DTOs
{
    public record CategoryDto(int Id, string Name, string Description, string Picture);
}
