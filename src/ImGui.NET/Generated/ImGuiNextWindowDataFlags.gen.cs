namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiNextWindowDataFlags
    {
        None = 0,
        HasPos = 1,
        HasSize = 2,
        HasContentSize = 4,
        HasCollapsed = 8,
        HasSizeConstraint = 16,
        HasFocus = 32,
        HasBgAlpha = 64,
        HasScroll = 128,
        HasChildFlags = 256,
        HasViewport = 512,
        HasDock = 1024,
        HasWindowClass = 2048,
    }
}
