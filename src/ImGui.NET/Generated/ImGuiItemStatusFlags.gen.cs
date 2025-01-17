namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiItemStatusFlags
    {
        None = 0,
        HoveredRect = 1,
        HasDisplayRect = 2,
        Edited = 4,
        ToggledSelection = 8,
        ToggledOpen = 16,
        HasDeactivated = 32,
        Deactivated = 64,
        HoveredWindow = 128,
        Visible = 256,
        HasClipRect = 512,
    }
}
