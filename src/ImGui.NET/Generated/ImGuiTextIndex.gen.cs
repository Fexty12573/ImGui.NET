using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiTextIndex
    {
        public ImVector LineOffsets;
        public int EndOffset;
    }
    public unsafe partial struct ImGuiTextIndexPtr
    {
        public ImGuiTextIndex* NativePtr { get; }
        public ImGuiTextIndexPtr(ImGuiTextIndex* nativePtr) => NativePtr = nativePtr;
        public ImGuiTextIndexPtr(IntPtr nativePtr) => NativePtr = (ImGuiTextIndex*)nativePtr;
        public static implicit operator ImGuiTextIndexPtr(ImGuiTextIndex* nativePtr) => new ImGuiTextIndexPtr(nativePtr);
        public static implicit operator ImGuiTextIndex* (ImGuiTextIndexPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiTextIndexPtr(IntPtr nativePtr) => new ImGuiTextIndexPtr(nativePtr);
        public static implicit operator IntPtr(ImGuiTextIndexPtr self) => (IntPtr)self.NativePtr;
        public ImVector<int> LineOffsets => new ImVector<int>(NativePtr->LineOffsets);
        public ref int EndOffset => ref Unsafe.AsRef<int>(&NativePtr->EndOffset);
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public void append(ReadOnlySpan<char> Base, int old_size, int new_size)
        {
            byte* native_Base;
            int Base_byteCount = 0;
            if (Base != null)
            {
                Base_byteCount = Encoding.UTF8.GetByteCount(Base);
                if (Base_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_Base = Util.Allocate(Base_byteCount + 1);
                }
                else
                {
                    byte* native_Base_stackBytes = stackalloc byte[Base_byteCount + 1];
                    native_Base = native_Base_stackBytes;
                }
                int native_Base_offset = Util.GetUtf8(Base, native_Base, Base_byteCount);
                native_Base[native_Base_offset] = 0;
            }
            else { native_Base = null; }
            ImGuiNative.ImGuiTextIndex_append((ImGuiTextIndex*)(NativePtr), native_Base, old_size, new_size);
            if (Base_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_Base);
            }
        }
#endif
        public void append(string Base, int old_size, int new_size)
        {
            byte* native_Base;
            int Base_byteCount = 0;
            if (Base != null)
            {
                Base_byteCount = Encoding.UTF8.GetByteCount(Base);
                if (Base_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_Base = Util.Allocate(Base_byteCount + 1);
                }
                else
                {
                    byte* native_Base_stackBytes = stackalloc byte[Base_byteCount + 1];
                    native_Base = native_Base_stackBytes;
                }
                int native_Base_offset = Util.GetUtf8(Base, native_Base, Base_byteCount);
                native_Base[native_Base_offset] = 0;
            }
            else { native_Base = null; }
            ImGuiNative.ImGuiTextIndex_append((ImGuiTextIndex*)(NativePtr), native_Base, old_size, new_size);
            if (Base_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_Base);
            }
        }
        public void clear()
        {
            ImGuiNative.ImGuiTextIndex_clear((ImGuiTextIndex*)(NativePtr));
        }
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public string get_line_begin(ReadOnlySpan<char> Base, int n)
        {
            byte* native_Base;
            int Base_byteCount = 0;
            if (Base != null)
            {
                Base_byteCount = Encoding.UTF8.GetByteCount(Base);
                if (Base_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_Base = Util.Allocate(Base_byteCount + 1);
                }
                else
                {
                    byte* native_Base_stackBytes = stackalloc byte[Base_byteCount + 1];
                    native_Base = native_Base_stackBytes;
                }
                int native_Base_offset = Util.GetUtf8(Base, native_Base, Base_byteCount);
                native_Base[native_Base_offset] = 0;
            }
            else { native_Base = null; }
            byte* ret = ImGuiNative.ImGuiTextIndex_get_line_begin((ImGuiTextIndex*)(NativePtr), native_Base, n);
            if (Base_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_Base);
            }
            return Util.StringFromPtr(ret);
        }
#endif
        public string get_line_begin(string Base, int n)
        {
            byte* native_Base;
            int Base_byteCount = 0;
            if (Base != null)
            {
                Base_byteCount = Encoding.UTF8.GetByteCount(Base);
                if (Base_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_Base = Util.Allocate(Base_byteCount + 1);
                }
                else
                {
                    byte* native_Base_stackBytes = stackalloc byte[Base_byteCount + 1];
                    native_Base = native_Base_stackBytes;
                }
                int native_Base_offset = Util.GetUtf8(Base, native_Base, Base_byteCount);
                native_Base[native_Base_offset] = 0;
            }
            else { native_Base = null; }
            byte* ret = ImGuiNative.ImGuiTextIndex_get_line_begin((ImGuiTextIndex*)(NativePtr), native_Base, n);
            if (Base_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_Base);
            }
            return Util.StringFromPtr(ret);
        }
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public string get_line_end(ReadOnlySpan<char> Base, int n)
        {
            byte* native_Base;
            int Base_byteCount = 0;
            if (Base != null)
            {
                Base_byteCount = Encoding.UTF8.GetByteCount(Base);
                if (Base_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_Base = Util.Allocate(Base_byteCount + 1);
                }
                else
                {
                    byte* native_Base_stackBytes = stackalloc byte[Base_byteCount + 1];
                    native_Base = native_Base_stackBytes;
                }
                int native_Base_offset = Util.GetUtf8(Base, native_Base, Base_byteCount);
                native_Base[native_Base_offset] = 0;
            }
            else { native_Base = null; }
            byte* ret = ImGuiNative.ImGuiTextIndex_get_line_end((ImGuiTextIndex*)(NativePtr), native_Base, n);
            if (Base_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_Base);
            }
            return Util.StringFromPtr(ret);
        }
#endif
        public string get_line_end(string Base, int n)
        {
            byte* native_Base;
            int Base_byteCount = 0;
            if (Base != null)
            {
                Base_byteCount = Encoding.UTF8.GetByteCount(Base);
                if (Base_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_Base = Util.Allocate(Base_byteCount + 1);
                }
                else
                {
                    byte* native_Base_stackBytes = stackalloc byte[Base_byteCount + 1];
                    native_Base = native_Base_stackBytes;
                }
                int native_Base_offset = Util.GetUtf8(Base, native_Base, Base_byteCount);
                native_Base[native_Base_offset] = 0;
            }
            else { native_Base = null; }
            byte* ret = ImGuiNative.ImGuiTextIndex_get_line_end((ImGuiTextIndex*)(NativePtr), native_Base, n);
            if (Base_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_Base);
            }
            return Util.StringFromPtr(ret);
        }
        public int size()
        {
            int ret = ImGuiNative.ImGuiTextIndex_size((ImGuiTextIndex*)(NativePtr));
            return ret;
        }
    }
}
