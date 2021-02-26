import random
import time
import json
from pylsl import StreamInfo, StreamOutlet, StreamInlet, resolve_stream


def receive_data():
    #results = resolve_stream("name", "Feedback")
    results = resolve_stream("name", "Marker")
    inlet = StreamInlet(results[0])

    while True:
        sample, timestamp = inlet.pull_sample()
        print(timestamp, sample[0])


receive_data()
