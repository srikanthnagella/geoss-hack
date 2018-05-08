from .models import Score, ImageTile, ImageFile
from rest_framework import serializers

class ScoreSerializer(serializers.ModelSerializer):
    class Meta:
        model = Score
        fields = '__all__'

class ImageFileSerializer(serializers.ModelSerializer):
    class Meta:
        model = ImageFile
        fields = '__all__'

class ImageTileSerializer(serializers.ModelSerializer):
    class Meta:
        model = ImageTile
        fields = '__all__'