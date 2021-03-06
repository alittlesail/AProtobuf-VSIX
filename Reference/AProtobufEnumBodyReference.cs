﻿
namespace ALittle
{
    public class AProtobufEnumBodyReference : AProtobufReferenceTemplate<AProtobufEnumBodyElement>
    {
        public AProtobufEnumBodyReference(ABnfElement element) : base(element) { }

        public override int GetDesiredIndentation(int offset, ABnfElement select)
        {
            ABnfElement parent = m_element.GetParent();
            if (parent is AProtobufEnumElement)
            {
                var childs = m_element.GetChilds();
                if (select is ABnfStringElement && (select.GetElementText() == "{" || (select.GetElementText() == "}" && childs.Count > 0 && childs[0].GetStartLine() != select.GetStartLine())))
                    return parent.GetReference().GetDesiredIndentation(offset, null);

                return parent.GetReference().GetDesiredIndentation(offset, null) + ALanguageSmartIndentProvider.s_indent_size;
            }
            return 0;
        }

        public override int GetFormateIndentation(int offset, ABnfElement select)
        {
            ABnfElement parent = m_element.GetParent();
            if (parent is AProtobufEnumElement)
            {
                if (select is ABnfStringElement && (select.GetElementText() == "{" || select.GetElementText() == "}"))
                    return parent.GetReference().GetFormateIndentation(offset, null);

                return parent.GetReference().GetFormateIndentation(offset, null) + ALanguageSmartIndentProvider.s_indent_size;
            }
            return 0;
        }
    }
}

