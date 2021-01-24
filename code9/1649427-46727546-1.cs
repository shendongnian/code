    <ListBox ItemsSource="{Binding QuestionSection.QuestionAssignments}"
             SelectedValuePath="QuestionId"
             SelectedValue="{Binding ActiveQuestionId}">
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListBoxItem">
                            <Expander IsExpanded="{Binding IsSelected,
                                          RelativeSource={RelativeSource TemplatedParent}}">
                                ...
                            </Expander>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
