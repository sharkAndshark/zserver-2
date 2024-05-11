namespace ZMap.Source;

public abstract class RasterSource : IRasterSource
{
    public string Key { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public int Srid { get; set; }

    /// <summary>
    /// 数据源读出的数据， 需要转码成图片
    /// </summary>
    /// <param name="extent"></param>
    /// <returns></returns>
    public abstract Task<byte[]> GetImageInExtentAsync(Envelope extent);

    public abstract Envelope GetEnvelope();
    public abstract ISource Clone();
    public abstract void Dispose();
}