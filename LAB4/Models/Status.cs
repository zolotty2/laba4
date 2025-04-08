﻿using System;
using System.Collections.Generic;

namespace LAB4.Models;

public partial class Status
{
    public short Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<TitlesStatus> TitlesStatuses { get; set; } = new List<TitlesStatus>();
}
