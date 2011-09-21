﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace ElasticSearch.Client
{
    [JsonObject]
    public class RangeFacet : Facet
    {
        [JsonProperty("ranges")]
        public IList<Range> Ranges { get; internal set; }

        #region Nested type: Range

        public class Range : FacetItem
        {
            [JsonProperty(PropertyName = "to")]
            public float? To { get; internal set; }

            [JsonProperty(PropertyName = "from")]
            public float? From { get; internal set; }

            [JsonProperty(PropertyName = "min")]
            public float Min { get; internal set; }

            [JsonProperty(PropertyName = "max")]
            public float Max { get; internal set; }

            [JsonProperty(PropertyName = "total_count")]
            public int TotalCount { get; internal set; }

            [JsonProperty(PropertyName = "total")]
            public float Total { get; internal set; }

            [JsonProperty(PropertyName = "mean")]
            public float Mean { get; internal set; }
        }

        #endregion
    }
}