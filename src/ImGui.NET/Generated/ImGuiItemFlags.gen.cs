namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiItemFlags
    {
        None = 0,
        NoTabStop = 1,
        ButtonRepeat = 2,
        Disabled = 4,
        NoNav = 8,
        NoNavDefaultFocus = 16,
        SelectableDontClosePopup = 32,
        MixedValue = 64,
        ReadOnly = 128,
        NoWindowHoverableCheck = 256,
        AllowOverlap = 512,
        Inputable = 1024,
        HasSelectionUserData = 2048,
    }
}
