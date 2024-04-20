﻿using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace ZMap.Ogc.Wms;

public record RequestArguments(
    Envelope Envelope,
    int SRID,
    IReadOnlyCollection<(string ResourceGroup, string Layer)> Layers);