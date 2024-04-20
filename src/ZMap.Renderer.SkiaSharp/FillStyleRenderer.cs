using SkiaSharp;
using ZMap.Renderer.SkiaSharp.Utilities;
using ZMap.Style;

namespace ZMap.Renderer.SkiaSharp;

public class FillStyleRenderer(FillStyle style) : SkiaRenderer, IFillStyleRenderer<SKCanvas>
{
    protected readonly FillStyle Style = style;

    protected override SKPaint CreatePaint()
    {
        var opacity = Style.Opacity.Value ?? 1;
        var color = Style.Color.Value;
        var antialias = Style.Antialias;

        return new SKPaint
        {
            Style = SKPaintStyle.Fill,
            IsAntialias = antialias,
            Color = ColorUtilities.GetColor(color, opacity)
        };
    }
}