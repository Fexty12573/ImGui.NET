using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

// NOTE:
// This is a direct copy from ImGui.Manual.cs with all string parameters (not ref string) changed to ReadOnlySpan<char>.
// This is far from ideal right now, maybe we could update the generator to do this for us.
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
namespace ImGuiNET
{
    public static unsafe partial class ImGui
    {
        public static bool InputText(
            ReadOnlySpan<char> label,
            byte[] buf,
            uint buf_size)
        {
            return InputText(label, buf, buf_size, 0, null, IntPtr.Zero);
        }

        public static bool InputText(
            ReadOnlySpan<char> label,
            byte[] buf,
            uint buf_size,
            ImGuiInputTextFlags flags)
        {
            return InputText(label, buf, buf_size, flags, null, IntPtr.Zero);
        }

        public static bool InputText(
            ReadOnlySpan<char> label,
            byte[] buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
        {
            return InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);
        }

        public static bool InputText(
            ReadOnlySpan<char> label,
            byte[] buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            bool ret;
            fixed (byte* bufPtr = buf)
            {
                ret = ImGuiNative.igInputText(utf8LabelBytes, bufPtr, buf_size, flags, callback, user_data.ToPointer()) != 0;
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }

            return ret;
        }

        public static bool InputText(
            ReadOnlySpan<char> label,
            ref string input,
            uint maxLength) => InputText(label, ref input, maxLength, 0, null, IntPtr.Zero);

        public static bool InputText(
            ReadOnlySpan<char> label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags) => InputText(label, ref input, maxLength, flags, null, IntPtr.Zero);

        public static bool InputText(
            ReadOnlySpan<char> label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputText(label, ref input, maxLength, flags, callback, IntPtr.Zero);

        public static bool InputText(
            ReadOnlySpan<char> label,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            int utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
            int inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

            byte* utf8InputBytes;
            byte* originalUtf8InputBytes;
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                utf8InputBytes = Util.Allocate(inputBufSize);
                originalUtf8InputBytes = Util.Allocate(inputBufSize);
            }
            else
            {
                byte* inputStackBytes = stackalloc byte[inputBufSize];
                utf8InputBytes = inputStackBytes;
                byte* originalInputStackBytes = stackalloc byte[inputBufSize];
                originalUtf8InputBytes = originalInputStackBytes;
            }
            Util.GetUtf8(input, utf8InputBytes, inputBufSize);
            uint clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
            Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
            Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

            byte result = ImGuiNative.igInputText(
                utf8LabelBytes,
                utf8InputBytes,
                (uint)inputBufSize,
                flags,
                callback,
                user_data.ToPointer());
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            {
                input = Util.StringFromPtr(utf8InputBytes);
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8InputBytes);
                Util.Free(originalUtf8InputBytes);
            }

            return result != 0;
        }

        public static bool InputTextMultiline(
            ReadOnlySpan<char> label,
            ref string input,
            uint maxLength,
            Vector2 size) => InputTextMultiline(label, ref input, maxLength, size, 0, null, IntPtr.Zero);

        public static bool InputTextMultiline(
            ReadOnlySpan<char> label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags) => InputTextMultiline(label, ref input, maxLength, size, flags, null, IntPtr.Zero);

        public static bool InputTextMultiline(
            ReadOnlySpan<char> label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextMultiline(label, ref input, maxLength, size, flags, callback, IntPtr.Zero);

        public static bool InputTextMultiline(
            ReadOnlySpan<char> label,
            ref string input,
            uint maxLength,
            Vector2 size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            int utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
            int inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

            byte* utf8InputBytes;
            byte* originalUtf8InputBytes;
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                utf8InputBytes = Util.Allocate(inputBufSize);
                originalUtf8InputBytes = Util.Allocate(inputBufSize);
            }
            else
            {
                byte* inputStackBytes = stackalloc byte[inputBufSize];
                utf8InputBytes = inputStackBytes;
                byte* originalInputStackBytes = stackalloc byte[inputBufSize];
                originalUtf8InputBytes = originalInputStackBytes;
            }
            Util.GetUtf8(input, utf8InputBytes, inputBufSize);
            uint clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
            Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
            Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

            byte result = ImGuiNative.igInputTextMultiline(
                utf8LabelBytes,
                utf8InputBytes,
                (uint)inputBufSize,
                size,
                flags,
                callback,
                user_data.ToPointer());
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            {
                input = Util.StringFromPtr(utf8InputBytes);
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8InputBytes);
                Util.Free(originalUtf8InputBytes);
            }

            return result != 0;
        }

        public static bool InputTextWithHint(
            ReadOnlySpan<char> label,
            ReadOnlySpan<char> hint,
            ref string input,
            uint maxLength) => InputTextWithHint(label, hint, ref input, maxLength, 0, null, IntPtr.Zero);

        public static bool InputTextWithHint(
            ReadOnlySpan<char> label,
            ReadOnlySpan<char> hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags) => InputTextWithHint(label, hint, ref input, maxLength, flags, null, IntPtr.Zero);

        public static bool InputTextWithHint(
            ReadOnlySpan<char> label,
            ReadOnlySpan<char> hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback) => InputTextWithHint(label, hint, ref input, maxLength, flags, callback, IntPtr.Zero);

        public static bool InputTextWithHint(
            ReadOnlySpan<char> label,
            ReadOnlySpan<char> hint,
            ref string input,
            uint maxLength,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            int utf8HintByteCount = Encoding.UTF8.GetByteCount(hint);
            byte* utf8HintBytes;
            if (utf8HintByteCount > Util.StackAllocationSizeLimit)
            {
                utf8HintBytes = Util.Allocate(utf8HintByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8HintByteCount + 1];
                utf8HintBytes = stackPtr;
            }
            Util.GetUtf8(hint, utf8HintBytes, utf8HintByteCount);

            int utf8InputByteCount = Encoding.UTF8.GetByteCount(input);
            int inputBufSize = Math.Max((int)maxLength + 1, utf8InputByteCount + 1);

            byte* utf8InputBytes;
            byte* originalUtf8InputBytes;
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                utf8InputBytes = Util.Allocate(inputBufSize);
                originalUtf8InputBytes = Util.Allocate(inputBufSize);
            }
            else
            {
                byte* inputStackBytes = stackalloc byte[inputBufSize];
                utf8InputBytes = inputStackBytes;
                byte* originalInputStackBytes = stackalloc byte[inputBufSize];
                originalUtf8InputBytes = originalInputStackBytes;
            }
            Util.GetUtf8(input, utf8InputBytes, inputBufSize);
            uint clearBytesCount = (uint)(inputBufSize - utf8InputByteCount);
            Unsafe.InitBlockUnaligned(utf8InputBytes + utf8InputByteCount, 0, clearBytesCount);
            Unsafe.CopyBlock(originalUtf8InputBytes, utf8InputBytes, (uint)inputBufSize);

            byte result = ImGuiNative.igInputTextWithHint(
                utf8LabelBytes,
                utf8HintBytes,
                utf8InputBytes,
                (uint)inputBufSize,
                flags,
                callback,
                user_data.ToPointer());
            if (!Util.AreStringsEqual(originalUtf8InputBytes, inputBufSize, utf8InputBytes))
            {
                input = Util.StringFromPtr(utf8InputBytes);
            }

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }
            if (utf8HintByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8HintBytes);
            }
            if (inputBufSize > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8InputBytes);
                Util.Free(originalUtf8InputBytes);
            }

            return result != 0;
        }

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start)
            => CalcTextSizeImpl(text, start);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, float wrapWidth)
            => CalcTextSizeImpl(text, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, int length)
            => CalcTextSizeImpl(text, start, length);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, hideTextAfterDoubleHash: hideTextAfterDoubleHash);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, float wrapWidth)
            => CalcTextSizeImpl(text, start, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, int length, bool hideTextAfterDoubleHash)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, int length, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, wrapWidth: wrapWidth);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, int start, int length, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash, wrapWidth);

        public static Vector2 CalcTextSize(ReadOnlySpan<char> text, bool hideTextAfterDoubleHash, float wrapWidth)
            => CalcTextSizeImpl(text, 0, null, hideTextAfterDoubleHash, wrapWidth);

        private static Vector2 CalcTextSizeImpl(
            ReadOnlySpan<char> text,
            int start = 0,
            int? length = null,
            bool hideTextAfterDoubleHash = false,
            float wrapWidth = -1.0f)
        {
            return CalcTextSize(text.Slice(start, length ?? text.Length-start), hideTextAfterDoubleHash, wrapWidth);
        }

        public static bool InputText(
            ReadOnlySpan<char> label,
            IntPtr buf,
            uint buf_size)
        {
            return InputText(label, buf, buf_size, 0, null, IntPtr.Zero);
        }

        public static bool InputText(
            ReadOnlySpan<char> label,
            IntPtr buf,
            uint buf_size,
            ImGuiInputTextFlags flags)
        {
            return InputText(label, buf, buf_size, flags, null, IntPtr.Zero);
        }

        public static bool InputText(
            ReadOnlySpan<char> label,
            IntPtr buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback)
        {
            return InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);
        }

        public static bool InputText(
            ReadOnlySpan<char> label,
            IntPtr buf,
            uint buf_size,
            ImGuiInputTextFlags flags,
            ImGuiInputTextCallback callback,
            IntPtr user_data)
        {
            int utf8LabelByteCount = Encoding.UTF8.GetByteCount(label);
            byte* utf8LabelBytes;
            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                utf8LabelBytes = Util.Allocate(utf8LabelByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8LabelByteCount + 1];
                utf8LabelBytes = stackPtr;
            }
            Util.GetUtf8(label, utf8LabelBytes, utf8LabelByteCount);

            bool ret = ImGuiNative.igInputText(utf8LabelBytes, (byte*)buf.ToPointer(), buf_size, flags, callback, user_data.ToPointer()) != 0;

            if (utf8LabelByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8LabelBytes);
            }

            return ret;
        }

        public static bool Begin(ReadOnlySpan<char> name, ImGuiWindowFlags flags)
        {
            int utf8NameByteCount = Encoding.UTF8.GetByteCount(name);
            byte* utf8NameBytes;
            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                utf8NameBytes = Util.Allocate(utf8NameByteCount + 1);
            }
            else
            {
                byte* stackPtr = stackalloc byte[utf8NameByteCount + 1];
                utf8NameBytes = stackPtr;
            }
            Util.GetUtf8(name, utf8NameBytes, utf8NameByteCount);

            byte* p_open = null;
            byte ret = ImGuiNative.igBegin(utf8NameBytes, p_open, flags);

            if (utf8NameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(utf8NameBytes);
            }

            return ret != 0;
        }

        public static bool MenuItem(ReadOnlySpan<char> label, bool enabled)
        {
            return MenuItem(label, string.Empty, false, enabled);
        }
    }
}
#endif
