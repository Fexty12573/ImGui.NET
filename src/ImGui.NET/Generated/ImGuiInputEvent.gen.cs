using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiInputEvent
    {
        public ImGuiInputEventType Type;
        public ImGuiInputSource Source;
        public uint EventId;
        public byte AddedByTestEngine;
    }
    public unsafe partial struct ImGuiInputEventPtr
    {
        public ImGuiInputEvent* NativePtr { get; }
        public ImGuiInputEventPtr(ImGuiInputEvent* nativePtr) => NativePtr = nativePtr;
        public ImGuiInputEventPtr(IntPtr nativePtr) => NativePtr = (ImGuiInputEvent*)nativePtr;
        public static implicit operator ImGuiInputEventPtr(ImGuiInputEvent* nativePtr) => new ImGuiInputEventPtr(nativePtr);
        public static implicit operator ImGuiInputEvent* (ImGuiInputEventPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiInputEventPtr(IntPtr nativePtr) => new ImGuiInputEventPtr(nativePtr);
        public static implicit operator IntPtr(ImGuiInputEventPtr self) => (IntPtr)self.NativePtr;
        public ref ImGuiInputEventType Type => ref Unsafe.AsRef<ImGuiInputEventType>(&NativePtr->Type);
        public ref ImGuiInputSource Source => ref Unsafe.AsRef<ImGuiInputSource>(&NativePtr->Source);
        public ref uint EventId => ref Unsafe.AsRef<uint>(&NativePtr->EventId);
        public ref bool AddedByTestEngine => ref Unsafe.AsRef<bool>(&NativePtr->AddedByTestEngine);
        public void Destroy()
        {
            ImGuiNative.ImGuiInputEvent_destroy((ImGuiInputEvent*)(NativePtr));
        }
    }
}
