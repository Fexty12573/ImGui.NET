namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiDebugLogFlags
    {
        None = 0,
        EventActiveId = 1,
        EventFocus = 2,
        EventPopup = 4,
        EventNav = 8,
        EventClipper = 16,
        EventSelection = 32,
        EventIO = 64,
        EventInputRouting = 128,
        EventDocking = 256,
        EventViewport = 512,
        EventMask = 1023,
        OutputToTTY = 1048576,
        OutputToTestEngine = 2097152,
    }
}
