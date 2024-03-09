namespace ImGuiNET
{
    [System.Flags]
    public enum ImGuiInputFlags
    {
        None = 0,
        Repeat = 1,
        RepeatRateDefault = 2,
        RepeatRateNavMove = 4,
        RepeatRateNavTweak = 8,
        RepeatUntilRelease = 16,
        RepeatUntilKeyModsChange = 32,
        RepeatUntilKeyModsChangeFromNone = 64,
        RepeatUntilOtherKeyPress = 128,
        CondHovered = 256,
        CondActive = 512,
        CondDefault = 768,
        LockThisFrame = 1024,
        LockUntilRelease = 2048,
        RouteFocused = 4096,
        RouteGlobalLow = 8192,
        RouteGlobal = 16384,
        RouteGlobalHigh = 32768,
        RouteAlways = 65536,
        RouteUnlessBgFocused = 131072,
        RepeatRateMask_ = 14,
        RepeatUntilMask_ = 240,
        RepeatMask_ = 255,
        CondMask = 768,
        RouteMask = 61440,
        SupportedByIsKeyPressed = 255,
        SupportedByIsMouseClicked = 1,
        SupportedByShortcut = 258303,
        SupportedBySetKeyOwner = 3072,
        SupportedBySetItemKeyOwner = 3840,
    }
}
