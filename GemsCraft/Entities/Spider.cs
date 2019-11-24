﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemsCraft.AppSystem.Types;
using GemsCraft.Entities.Metadata;

namespace GemsCraft.Entities
{
    public class Spider: Monster
    {
        public EntityMetadata IsClimbing = new EntityMetadata(
            12,
            EntityMetadataType.Byte,
            0
        );
    }
}
