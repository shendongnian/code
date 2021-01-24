	<Storyboard x:Name="ImageStoryboard">
		<DoubleAnimationUsingKeyFrames
			Storyboard.TargetName="ImageTransform"
			Storyboard.TargetProperty="X"
			Duration="0:0:12" 
			EnableDependentAnimation="True" 
			RepeatBehavior="Forever">
			<LinearDoubleKeyFrame Value="378" KeyTime="0:0:0"/>
			<LinearDoubleKeyFrame Value="549" KeyTime="0:0:3"/>
			<LinearDoubleKeyFrame Value="720" KeyTime="0:0:6"/>
			<LinearDoubleKeyFrame Value="890" KeyTime="0:0:9"/>
			<LinearDoubleKeyFrame Value="378" KeyTime="0:0:12"/>
		</DoubleAnimationUsingKeyFrames>
		<DoubleAnimationUsingKeyFrames
			Storyboard.TargetName="ImageTransform"
			Storyboard.TargetProperty="Y"
			Duration="0:0:3" 
			EnableDependentAnimation="True" 
			RepeatBehavior="Forever">
			<EasingDoubleKeyFrame Value="606" KeyTime="0:0:0">
				<EasingDoubleKeyFrame.EasingFunction>
					<CircleEase EasingMode="EaseOut" />
				</EasingDoubleKeyFrame.EasingFunction>
			</EasingDoubleKeyFrame>
			<EasingDoubleKeyFrame Value="500" KeyTime="0:0:1.5">
				<EasingDoubleKeyFrame.EasingFunction>
					<CircleEase EasingMode="EaseOut" />
				</EasingDoubleKeyFrame.EasingFunction>
			</EasingDoubleKeyFrame>
			<EasingDoubleKeyFrame Value="606" KeyTime="0:0:3">
				<EasingDoubleKeyFrame.EasingFunction>
					<CircleEase EasingMode="EaseIn" />
				</EasingDoubleKeyFrame.EasingFunction>
			</EasingDoubleKeyFrame>
		</DoubleAnimationUsingKeyFrames>
	</Storyboard>
	<Image x:Name="Image" ...>
		<Image.RenderTransform>
			<TranslateTransform x:Name="ImageTransform" />
		</Image.RenderTransform>
	</Image>
