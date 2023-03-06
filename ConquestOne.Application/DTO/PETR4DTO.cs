using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConquestOne.Application.DTO
{
    public class PETR4DTO
    {
        [JsonPropertyName("chart")]
        public Chart Chart { get; set; }
    }

    public class Chart
    {
        [JsonPropertyName("result")]
        public List<Result> Result { get; set; }

        [JsonPropertyName("error")]
        public object Error { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("timestamp")]
        public List<long> Timestamp { get; set; }

        [JsonPropertyName("indicators")]
        public Indicators Indicators { get; set; }
    }

    public class Indicators
    {
        [JsonPropertyName("quote")]
        public List<Quote> Quote { get; set; }
    }

    public class Quote
    {
        [JsonPropertyName("close")]
        public List<double> Close { get; set; }

        [JsonPropertyName("volume")]
        public List<long> Volume { get; set; }

        [JsonPropertyName("open")]
        public List<double> Open { get; set; }

        [JsonPropertyName("high")]
        public List<double> High { get; set; }

        [JsonPropertyName("low")]
        public List<double> Low { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("exchangeName")]
        public string ExchangeName { get; set; }

        [JsonPropertyName("instrumentType")]
        public string InstrumentType { get; set; }

        [JsonPropertyName("firstTradeDate")]
        public long FirstTradeDate { get; set; }

        [JsonPropertyName("regularMarketTime")]
        public long RegularMarketTime { get; set; }

        [JsonPropertyName("gmtoffset")]
        public long Gmtoffset { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("exchangeTimezoneName")]
        public string ExchangeTimezoneName { get; set; }

        [JsonPropertyName("regularMarketPrice")]
        public double RegularMarketPrice { get; set; }

        [JsonPropertyName("chartPreviousClose")]
        public double ChartPreviousClose { get; set; }

        [JsonPropertyName("previousClose")]
        public double PreviousClose { get; set; }

        [JsonPropertyName("scale")]
        public long Scale { get; set; }

        [JsonPropertyName("priceHint")]
        public long PriceHint { get; set; }

        [JsonPropertyName("currentTradingPeriod")]
        public CurrentTradingPeriod CurrentTradingPeriod { get; set; }

        [JsonPropertyName("tradingPeriods")]
        public List<List<Post>> TradingPeriods { get; set; }

        [JsonPropertyName("dataGranularity")]
        public string DataGranularity { get; set; }

        [JsonPropertyName("range")]
        public string Range { get; set; }

        [JsonPropertyName("validRanges")]
        public List<string> ValidRanges { get; set; }
    }

    public class CurrentTradingPeriod
    {
        [JsonPropertyName("pre")]
        public Post Pre { get; set; }

        [JsonPropertyName("regular")]
        public Post Regular { get; set; }

        [JsonPropertyName("post")]
        public Post Post { get; set; }
    }

    public class Post
    {
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("start")]
        public long Start { get; set; }

        [JsonPropertyName("end")]
        public long End { get; set; }

        [JsonPropertyName("gmtoffset")]
        public long Gmtoffset { get; set; }
    }
}